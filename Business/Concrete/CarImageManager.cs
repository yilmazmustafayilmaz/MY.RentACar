using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Helpers.FileHelpers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{

    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;
        IFileHelper _fileHelper;
        public CarImageManager(ICarImageDal carImageDal, IFileHelper fileHelper)
        {
            _carImageDal = carImageDal;
            _fileHelper = fileHelper;
        }
        public IResult Add(CarImage carImage)
        {
            IResult result = BusinessRules.Run(CheckIfCarImageLimit(carImage.CarId));
            if (result != null)
                return result;
            
            carImage.ImagePath = _fileHelper.Upload(carImage.File, FilePath.ImagesPath);
            carImage.Date = DateTime.Now;
            _carImageDal.Add(carImage);
            return new SuccessResult("Resim başarıyla yüklendi");
        }

        public IResult Delete(int id)
        {
            var deleteCarImage = _carImageDal.Get(x => x.Id == id);
            _fileHelper.Delete(FilePath.ImagesPath + deleteCarImage.ImagePath);
            _carImageDal.Delete(deleteCarImage);
            return new SuccessResult("Resim başarıyla silindi");
        }
        public IResult Update(CarImage carImage)
        {
            var updateCarImage = _carImageDal.Get(x => x.Id == carImage.Id);
            updateCarImage.ImagePath = _fileHelper.Update(carImage.File, FilePath.ImagesPath + updateCarImage.ImagePath, FilePath.ImagesPath);
            _carImageDal.Update(updateCarImage);
            return new SuccessResult("Resim başarıyla güncellendi");
        }

        public IDataResult<List<CarImage>> GetByCarId(int carId)
        {
            var result = BusinessRules.Run(CheckCarImage(carId));
            if (result != null)
                return new ErrorDataResult<List<CarImage>>(GetDefaultImage(carId).Data);
            
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(c => c.CarId == carId));
        }

        public IDataResult<CarImage> GetByImageId(int imageId)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(c => c.Id == imageId));
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }
        private IResult CheckIfCarImageLimit(int carId)
        {
            var result = _carImageDal.GetAll(c => c.CarId == carId).Count;
            return result >= 5 ? new ErrorResult() : new SuccessResult();
        }
        private IDataResult<List<CarImage>> GetDefaultImage(int carId)
        {

            List<CarImage> carImage = new List<CarImage>();
            carImage.Add(new CarImage { CarId = carId, Date = DateTime.Now, ImagePath = "DefaultImage.jpg" });
            return new SuccessDataResult<List<CarImage>>(carImage);
        }
        private IResult CheckCarImage(int carId)
        {
            var result = _carImageDal.GetAll(c => c.CarId == carId).Count;
            return result > 0 ? new SuccessResult() : new ErrorResult();        }
    }
}


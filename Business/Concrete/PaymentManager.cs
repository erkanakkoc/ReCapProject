using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class PaymentManager : IPaymentService
    {
        IPaymentDal _paymentDal;

        public PaymentManager(IPaymentDal paymentDal)
        {
            _paymentDal = paymentDal;
        }

        public IResult Add(Payment payment)
        {
            _paymentDal.Add(payment);
            return new SuccessResult(Messages.SuccessfullyPaid);
        }

        public IResult CheckPayment(Payment payment)
        {
            var paymentToCheck = _paymentDal.GetAll(p => p.CardNumber == payment.CardNumber &&
            p.CVV == payment.CVV &&
            p.ExpirationDate == payment.ExpirationDate).Any();
            if (paymentToCheck)
            {
                return new SuccessResult(Messages.PaymentSucceeded);
            }
            else
            {
                return new ErrorResult(Messages.PaymentError);
            }
        }
    }
}

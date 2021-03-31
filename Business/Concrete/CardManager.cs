using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CardManager : ICardService
    {
        ICardDal _cardDal;

        public CardManager(ICardDal cardDal)
        {
            _cardDal = cardDal;
        }

        public IResult AddCard(Card card)
        {
            _cardDal.Add(card);
            return new SuccessResult(Messages.CardAdded);
        }

        public IDataResult<List<Card>> GetCardsByUserId(int userId)
        {
            return new SuccessDataResult<List<Card>>(_cardDal.GetAll(c => c.UserId == userId));
        }
    }
}

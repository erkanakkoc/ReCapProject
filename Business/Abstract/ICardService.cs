using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICardService
    {
        IResult AddCard(Card card);
        IDataResult<List<Card>> GetCardsByUserId(int userId);
    }
}

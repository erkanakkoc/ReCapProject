using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public interface IDataResult<T>:IResult
    {
        //Mesajla işlem sonucunu IResult içeriyor bu yüzden tekrar yazmak yerine buraya dahil ediyoruz.
        //Mesaj ve işlem sonucu (true, false) dışında birde T türünde data olacak.
        T Data { get; }
    }
}

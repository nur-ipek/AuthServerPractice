using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLibrary.DTOs
{
    public class ErrorDto //Tüm apilerimizin kullanacağı hata durumu
    {
        #region constructor
        public ErrorDto()
        {
            Errors = new List<String>();
        }
        
        //ERRORDTO İMPL. EDİLMEK İSTENDİĞİNDE  TEK HATA DURUMU VARSA
        public ErrorDto(string error, bool isShow)
        {
            Errors.Add(error);
            IsShow = isShow;
        }
        //HATA LİSTESİ
        public ErrorDto(List<string> errors, bool isShow)
        {
            Errors = errors;
            IsShow = isShow;
        }
        #endregion

        #region property
        //KULLANICI HATA ALDIĞINDA 2 PROPERTY'Sİ OLACAK

        //private set --> dışarıdan biri bu property'leri set etmek isterse constructor kullanarak yapmalı..!111!!!!
        public List<String> Errors { get; private set; } //Hatalar birden fazla olabilir.
        public bool IsShow { get; private set; } // Kullanıcıya gösterilmesini istemediğimiz hataların değerini 0 yaparız. IsShow değeri 0 olan hataları Developer görür, 1 olanları kullanıcı
        #endregion



    }
}
 
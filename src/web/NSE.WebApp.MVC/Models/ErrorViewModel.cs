using System.Collections.Generic;

namespace NSE.WebApp.MVC.Models
{
	public class ErrorViewModel
	{
		public string Titulo { get; set; }

        public string Mensagem { get; set; }

        public int ErroCode { get; set; }
    }

    public class ResponseResult
    {
        public string Title { get; set; }
        public int Status { get; set; }
        public ResponseErrorMessages Errors { get; set; }
    }

    public class ResponseErrorMessages
    {
        public List<string> Mensagens { get; set; }
    }
}

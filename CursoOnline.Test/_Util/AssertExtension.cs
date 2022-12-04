using System;
using Xunit;

namespace CursoOnline.Test.Util
{
    public static class AssertExtension
    {

        public static void ExecaoComMensagem(this ArgumentException exception, string mensagem) 
        {
            if (exception.Message == mensagem)
                Assert.True(true);
            else
                Assert.True(false, $"Esperava a mensagem '{mensagem}' ");
        }
    }
}

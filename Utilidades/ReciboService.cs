namespace Obligatorio.Utilidades
{
    public static class ReciboService
    {
        public static string GenerarNroRecibo()
        {
            Guid guid = Guid.NewGuid();

            byte[] bytes = guid.ToByteArray();
            long nro = BitConverter.ToInt64(bytes, 0);

            nro = Math.Abs(nro);

            string recibo = nro.ToString();
            if (recibo.Length > 12)
            {
                recibo = recibo.Substring(0, 12);
            }
            return recibo;
        }
    }
}

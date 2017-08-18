using System;
using System.Data.SqlClient;

namespace Concessionaria.Repositorio
{
    public static class SQLExtension
    {
        #region : Nãonulas :

        public static string ReadAsString(this SqlDataReader r, string campo)
        {
            return r.GetString(r.GetOrdinal(campo));
        }

        public static int ReadAsInt(this SqlDataReader r, string campo)
        {
            return r.GetInt32(r.GetOrdinal(campo));
        }

        public static decimal ReadAsDecimal(this SqlDataReader r, string campo)
        {
            return r.GetDecimal(r.GetOrdinal(campo));
        }

        public static DateTime ReadAsDateTime(this SqlDataReader r, string campo)
        {
            return r.GetDateTime(r.GetOrdinal(campo));
        }

        #endregion
        
        #region Nulas
        public static string ReadAsStringNull(this SqlDataReader r, string name)
        {
            var ordinal = r.GetOrdinal(name);
            return r.IsDBNull(ordinal) ? (string)null : r.GetString(ordinal);
        }

        public static DateTime? ReadAsDateTimeNull(this SqlDataReader r, string campo)
        {
            var ordinal = r.GetOrdinal(campo);
            return r.IsDBNull(ordinal) ? (DateTime?)null : r.GetDateTime(ordinal);
        }

        public static int? ReadAsIntNull(this SqlDataReader r, string campo)
        {
            var ordinal = r.GetOrdinal(campo);
            return r.IsDBNull(ordinal) ? (int?)null : r.GetInt32(ordinal);
        }

        public static Decimal? ReadAsDecimalNull(this SqlDataReader r, string campo)
        {
            var ordinal = r.GetOrdinal(campo);
            return r.IsDBNull(ordinal) ? (Decimal?)null : r.GetDecimal(ordinal);
        }
        #endregion
    }
}

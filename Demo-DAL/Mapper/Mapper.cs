    using Demo_DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_DAL
{
    static class Mapper
    {
        public static Client ToClient(this IDataRecord record)
        {
            if (record is null) return null;
            return new Client()
            {
                Client_Id = (int)record[nameof(Client.Client_Id)],
                nom = (string)record[nameof(Client.nom)],
                prenom = (string)record[nameof(Client.prenom)],
                email = (string)record[nameof(Client.email)],
                pass = "********",
                telephone = (int)record[nameof(Client.telephone)],
                pays = (string)record[nameof(Client.pays)]

            };
        }

        public static Reservation ToReservation(this IDataRecord record)
        {
            if (record is null) return null;
            return new Reservation()
            {
                Reservation_id = (int)record[nameof(Reservation.Reservation_id)],
                checkIn = (DateTime)record[nameof(Reservation.checkIn)],
                checkOut = (DateTime)record[nameof(Reservation.checkOut)],
                PrixTotal = (decimal)record[nameof(Reservation.PrixTotal)],
                nomAdultes = (int)record[nameof(Reservation.nomAdultes)],
                Logement_id = (int)record[nameof(Reservation.Logement_id)],
                Client_id = (int)record[nameof(Reservation.Client_id)],
                nomEnfants = (int)record[nameof(Reservation.nomEnfants)],
                nom = (string)record[nameof(Reservation.nom)],
                DescriptionCourte = (string)record[nameof(Reservation.DescriptionCourte)],



            };
        }

        public static Entities.TypeLogement ToTypeLogement(this IDataRecord record)
        {
            if (record is null) return null;
            return new Entities.TypeLogement()
            {
                Type_id = (int)record[nameof(Entities.TypeLogement.Type_id)],
                nom = (string)record[nameof(Entities.TypeLogement.nom)]
            };
        }

        public static Entities.Proprietaire ToProprietaire(this IDataRecord record)
        {
            if (record is null) return null;
            return new Entities.Proprietaire()
            {
                Client_id = (int)record[nameof(Entities.Proprietaire.Client_id)]
            };
        }

        public static Entities.Logement ToLogement(this IDataRecord record)
        {
            if (record is null) return null;
            var e = new Entities.Logement()
            {
                Logement_id = (int)record[nameof(Logement.Logement_id)],
                nom = (string)record[nameof(Logement.nom)],
                rue = (string)record[nameof(Logement.rue)],
                nombrePieces = (int)record[nameof(Logement.nombrePieces)],
                date_add = (DateTime)record[nameof(Logement.date_add)],
                DescriptionCourte = (string)record[nameof(Logement.DescriptionCourte)],
                Prix = (string)record[nameof(Logement.Prix)],
                Client_id = (int)record[nameof(Logement.Client_id)],
                email = (string)record[nameof(Logement.email)],
            };

            return e;
        }
    }
}

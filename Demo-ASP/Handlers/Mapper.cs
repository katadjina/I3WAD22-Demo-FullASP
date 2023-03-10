using Demo_ASP.Models.ClientViewModels;
using Demo_ASP.Models.LogementViewModels;
using Demo_ASP.Models.ReservationViewModels;
using Demo_BLL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo_ASP.Handlers
{
    public static class Mapper
    {
        #region Mappers Client
        public static ClientListItem ToListItem(this Client entity)
        {
            if (entity is null) return null;
            return new ClientListItem()
            {
                Client_id = entity.Client_Id,
                nom = entity.nom,
                prenom = entity.prenom,

            };
        }

        public static ClientListItem ToDetails(this Client entity)
        {
            if (entity is null) return null;
            return new ClientListItem()
            {
                Client_id = entity.Client_Id,
                nom = entity.nom,
                prenom = entity.prenom,

            };
        }

        public static Client ToBLL(this ClientCreateForm entity)
        {
            if (entity is null) return null;
            return new Client()
            {
                nom = entity.nom,
                prenom = entity.prenom,
                email = entity.email,
                pass = entity.pass,
                pays = entity.pays,
                telephone = entity.telephone
            };
        }

        public static ClientCreateForm ToEdit(this Client entity)
        {
            if (entity is null) return null;
            var client = new ClientCreateForm();
            client.Client_id = entity.Client_Id;
            client.nom = entity.nom;
            client.prenom = entity.prenom;
            client.pass = "********";
            client.confirmPass = "********";
            client.email = entity.email;
            client.telephone = entity.telephone;
            client.pays = entity.pays;
            return client;
        }
        #endregion

        #region Mappers Logement
        public static LogementListItem ToListItem(this Logement entity)
        {
            if (entity is null) return null;

            return new LogementListItem()
            {
                Logement_id = entity.Logement_id,
                nom = entity.nom,
                rue = entity.rue,
                nombrePiece = entity.nombrePiece,
                Prix = entity.Prix,
                Client_id = entity.Client_id,
                email = entity.email,
                Description = entity.Description,
                
            };
        }

        public static LogementDetails ToDetails(this Logement entity)
        {
            if (entity is null) return null;
            return new LogementDetails()
            {
                Logement_id = entity.Logement_id,
                nom = entity.nom,
                Description = entity.Description,
                rue = entity.rue,
                Prix = entity.Prix,
                nombrePiece = entity.nombrePiece,
                email = entity.email,
                Client_id = entity.Client_id,
            };
        }

        //public static LogementDelete ToDelete(this Logement entity)
        //{
        //    if (entity is null) return null;
        //    return new LogementDelete()
        //    {
        //        idLogement = entity.idLogement,
        //        nom = entity.nom
        //    };
        //}

        public static LogementEditForm ToEdit(this Logement entity)
        {
            if (entity is null) return null;
            return new LogementEditForm()
            {
                Logement_id = entity.Logement_id,
                nom = entity.nom,
                Description = entity.Description,
                rue = entity.rue,
                date_add = entity.date_add,
                Prix = entity.Prix,
                nombrePiece = entity.nombrePiece,
                email = entity.email,
                Client_id = entity.Client_id,
            };
        }

        public static Logement ToBLL(this LogementCreateForm entity)
        {
            if (entity is null) return null;

            var logement = new Logement();
            logement.nom = entity.nom;
            logement.Description = entity.Description;
            logement.nombrePiece = entity.nombrePiece;
            logement.rue = entity.rue;
            logement.date_add = entity.date_add;
            logement.Client_id = entity.Client_id;
            logement.email = entity.email;
            logement.Prix = entity.Prix;

            return logement;
        }

        public static Logement ToBLL(this LogementEditForm entity)
        {
            if (entity is null) return null;
            var logement = new Logement();
            logement.nom = entity.nom;
            logement.Description = entity.Description;
            logement.nombrePiece = entity.nombrePiece;
            logement.rue = entity.rue;
            logement.email = entity.email;
            logement.Client_id = entity.Client_id;
            logement.Prix = entity.Prix;
            return logement;
        }
        #endregion

        /// //////////////////////////////////////////////////////


        #region Mappers Reservation
        public static ReservationListItem ToListItem(this Reservation entity)
        {
            if (entity is null) return null;

            return new ReservationListItem()
            {
                Reservation_id = entity.Reservation_id,
                checkIn = entity.checkIn,
                checkOut = entity.checkOut,
                nombreAdultes = entity.nombreAdultes,
                nombreEnfants = entity.nombreEnfants,
                prix = entity.PrixTotal,
                Client_id = entity.Client_id,
                Logement_id = entity.Logement_id,
                nom = entity.nom,
                DescriptionCourte = entity.DescriptionCourte
            };
        }

        public static ReservationDetails ToDetails(this Reservation entity)
        {
            if (entity is null) return null;
            return new ReservationDetails()
            {
                Reservation_id = entity.Reservation_id,
                checkIn = entity.checkIn,
                checkOut = entity.checkOut,
                nombreAdultes = entity.nombreAdultes,
                nombreEnfants = entity.nombreEnfants,
                prix = entity.PrixTotal,
                Client_id = entity.Client_id,
                Logement_id = entity.Logement_id,
                
                
        };
        }

        //public static ReservationDelete ToDelete(this Reservation entity)
        //{
        //    if (entity is null) return null;
        //    return new ReservationDelete()
        //    {
        //        idReservation = entity.idReservation,
        //        nom = entity.nom
        //    };
        //}



        public static ReservationEditForm ToEdit(this Reservation entity)
        {
            if (entity is null) return null;
            return new ReservationEditForm()
            {
                Reservation_id = entity.Reservation_id,
                checkIn = entity.checkIn,
                checkOut = entity.checkOut,
                prix = (int)entity.PrixTotal,
                nombreAdultes = entity.nombreAdultes,
                nombreEnfants = entity.nombreEnfants,
                Client_id = entity.Client_id,
                Logement_id = entity.Logement_id,

            };
        }

        public static Reservation ToBLL(this ReservationCreateForm entity)
        {
            if (entity is null) return null;

            var reservation = new Reservation();
            reservation.checkIn = entity.checkIn;
            reservation.checkOut = entity.checkOut;
            reservation.nombreAdultes = entity.nombreAdultes;
            reservation.nombreEnfants = entity.nombreEnfants;
            reservation.PrixTotal = 100; // desolée :<
            reservation.Client_id = entity.Client_id;
            reservation.Logement_id = entity.Logement_id;

            return reservation;
        }

        public static Reservation ToBLL(this ReservationEditForm entity)
        {
            if (entity is null) return null;
            var reservation = new Reservation();
            reservation.Reservation_id = entity.Reservation_id;
            reservation.checkIn = entity.checkIn;
            reservation.checkOut = entity.checkOut;
            reservation.nombreAdultes = entity.nombreAdultes;
            reservation.nombreEnfants = entity.nombreEnfants;
            reservation.PrixTotal = entity.prix;
            reservation.Client_id = entity.Client_id;
            reservation.Logement_id = entity.Logement_id;
            return reservation;
        }
        #endregion
    }
}

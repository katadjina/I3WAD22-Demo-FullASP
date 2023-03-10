using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL = Demo_BLL.Entities;
using DAL = Demo_DAL.Entities;

namespace Demo_BLL
{
    static class Mapper
    {
        #region Mapper Client
        public static BLL.Client ToBLL(this DAL.Client entity)
        {
            if (entity is null) return null;
            return new BLL.Client()
            {
                Client_Id = entity.Client_Id,
                nom = entity.nom,
                prenom = entity.prenom,
                email = entity.email,
                pass = entity.pass,
                pays = entity.pays,
                telephone = entity.telephone
            };
        }

        public static DAL.Client ToDAL(this BLL.Client entity)
        {
            if (entity is null) return null;
            return new DAL.Client()
            {
                Client_Id = entity.Client_Id,
                nom = entity.nom,
                prenom = entity.prenom,
                email = entity.email,
                pass = entity.pass,
                pays = entity.pays,
                telephone = entity.telephone,

            };
        }
        #endregion

        #region Mapper Reservation
        public static BLL.Reservation ToBLL(this DAL.Reservation entity)
        {
            if (entity is null) return null;
            return new BLL.Reservation()
            {
                Reservation_id = entity.Reservation_id,
                checkIn = entity.checkIn,
                checkOut = entity.checkOut,
                PrixTotal = entity.PrixTotal,
                nombreAdultes = entity.nomAdultes,
                nombreEnfants = entity.nomEnfants,
                Client_id = entity.Client_id,
                Logement_id = entity.Logement_id,
                nom = entity.nom,
                DescriptionCourte = entity.DescriptionCourte
            };
        }

        public static DAL.Reservation ToDAL(this BLL.Reservation entity)
        {
            if (entity is null) return null;
            return new DAL.Reservation()
            {
                Reservation_id = entity.Reservation_id,
                checkIn = entity.checkIn,
                checkOut = entity.checkOut,
                PrixTotal = entity.PrixTotal,
                nomAdultes = entity.nombreAdultes,
                nomEnfants = entity.nombreEnfants,
                Client_id = entity.Client_id,
                Logement_id = entity.Logement_id,
                nom = entity.nom,
                DescriptionCourte = entity.DescriptionCourte

            };
        }
        #endregion

        #region Mapper TypeLogement
        public static BLL.TypeLogement ToBLL(this DAL.TypeLogement entity)
        {
            if (entity is null) return null;
            return new BLL.TypeLogement()
            {
                Type_id = entity.Type_id,
                nom = entity.nom
            };
        }

        public static DAL.TypeLogement ToDAL(this BLL.TypeLogement entity)
        {
            if (entity is null) return null;
            return new DAL.TypeLogement()
            {
                Type_id = entity.Type_id,
                nom = entity.nom
            };
        }
        #endregion

        #region Mapper Logement
        public static BLL.Logement ToBLL(this DAL.Logement entity)
        {
            if (entity is null) return null;
            return new BLL.Logement()
            {
                Logement_id = entity.Logement_id,
                nom = entity.nom,
                nombrePiece = entity.nombrePieces,
                date_add = entity.date_add,
                Description = entity.DescriptionCourte,
                Prix = entity.Prix,
                rue = entity.rue,
                Client_id = entity.Client_id,
                email = entity.email
            
                

             };
        }

        public static DAL.Logement ToDAL(this BLL.Logement entity)
        {
            if (entity is null) return null;
            return new DAL.Logement()
            {
                Logement_id = entity.Logement_id,
                nom = entity.nom,
                nombrePieces = entity.nombrePiece,
                date_add = entity.date_add,
                DescriptionCourte = entity.Description,
                Prix = entity.Prix,
                rue = entity.rue,
                Client_id = entity.Client_id,
                email = entity.email

            };
        }
        #endregion

        #region Mapper Proprietaire
        public static BLL.Proprietaire ToBLL(this DAL.Proprietaire entity)
        {
            if (entity is null) return null;
            return new BLL.Proprietaire()
            {
                Client_id = entity.Client_id

            };
        }

        public static DAL.Proprietaire ToDAL(this BLL.Proprietaire entity)
        {
            if (entity is null) return null;
            return new DAL.Proprietaire()
            {
                Client_id = entity.Client_id

            };
        }
        #endregion
    }
}

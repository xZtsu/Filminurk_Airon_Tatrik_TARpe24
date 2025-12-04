using Filminurk.Core.Domain;
using Filminurk.Core.Dto;
using Filminurk.Core.ServiceInterface;
using Filminurk.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filminurk.ApplicationServices.Services
{
    public class FavouriteListsServices : IFavouriteListsServices
    {
        private readonly FilminurkTARpe24Context _context;
        private readonly IFilesServices _filesServices;

        public FavouriteListsServices(FilminurkTARpe24Context context, IFilesServices filesServices)
        {
            _context = context;
            _filesServices = filesServices;
        }

        public async Task<FavouriteList> DetailAsync(Guid id)
        {
            var result = await _context.FavouriteLists
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.FavouriteListID == id);
            return result;
        }
        public async Task<FavouriteList> Create(FavouriteListDTO dto/*, List<Movie> selectedMovies*/)
        {
            FavouriteList newList = new();
            newList.FavouriteListID = Guid.NewGuid();
            newList.ListName = dto.ListName;
            newList.ListDescription = dto.ListDescription;
            newList.ListCreatedAt = dto.ListCreatedAt;
            newList.ListBelongsToUser = dto.ListBelongsToUser;
            newList.ListModifiedAt = dto.ListModifiedAt;
            newList.ListDeletedAt = dto.ListDeletedAt;
            newList.ListOfMovies = dto.ListOfMovies;
            // newList.ListOfMovies = selectedMovies;
            await _context.FavouriteLists.AddAsync(newList);
            await _context.SaveChangesAsync();

            //foreach (var movieid in selectedMovies)
            //{
            //    _context.FavouriteLists.Entry
            //}
            return newList;
        }
        public async Task<FavouriteList> Update(FavouriteListDTO updatedList, string typeOfMethod)
        {
            FavouriteList updatedListInDB = new();

            updatedListInDB.FavouriteListID = (Guid)updatedList.FavouriteListID;
            updatedListInDB.ListBelongsToUser = updatedList.ListBelongsToUser;
            updatedListInDB.isMovieOrActor = (bool)updatedList.isMovieOrActor;
            updatedListInDB.ListName = updatedList.ListName;
            updatedListInDB.ListDescription = updatedList.ListDescription;
            updatedListInDB.IsPrivate = (bool)updatedList.IsPrivate;
            updatedListInDB.ListOfMovies = updatedList.ListOfMovies;
            updatedListInDB.ListCreatedAt = updatedList.ListCreatedAt;
            updatedListInDB.ListDeletedAt = updatedList.ListDeletedAt;
            updatedListInDB.ListModifiedAt = updatedList.ListModifiedAt;
            if(typeOfMethod == "Delete")
            {
                
                _context.Entry(updatedListInDB).Property(l => l.ListDeletedAt).IsModified = true;
                
            }
            
            if(typeOfMethod == "private")
            {
                
                _context.Entry(updatedListInDB).Property(l => l.IsPrivate).IsModified = true;
               
            }
            _context.Entry(updatedListInDB).Property(l => l.ListModifiedAt).IsModified = true;

            await _context.SaveChangesAsync();
            return updatedListInDB;

            //}
        }
    }
}

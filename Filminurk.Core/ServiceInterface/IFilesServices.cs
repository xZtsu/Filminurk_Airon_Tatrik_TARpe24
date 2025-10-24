﻿using Filminurk.Core.Domain;
using Filminurk.Core.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filminurk.Core.ServiceInterface
{
    public interface IFilesServices
    {
        void FilesToApi(MoviesDTO dto, Movie domain);
        Task<FileToApi> RemoveImageFromApi(FileToApiDTO dto);
        Task<List<FileToApi>> RemoveImagesFromApi(FileToApiDTO[] dtos);
    }

}
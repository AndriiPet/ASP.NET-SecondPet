using AutoMapper;
using BLL.Interfaces;
using BLL.Models;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace BLL.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public AuthorService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task AddAsync(AuthorDto model)
        {
            Author mappedAuthor = _mapper.Map<AuthorDto, Author>(model);
           
            if (mappedAuthor == null)
            {
                throw new System.Exception("Author wasn't found");
            }
            else { 
            await _unitOfWork.AuthorRepository.AddAsync(mappedAuthor);
            await _unitOfWork.SaveAsync();
            }

        }

        public async Task DeleteByIdAsync(int modelId)
        {
            Author mappedAuthor = await _unitOfWork.AuthorRepository.GetByIdAsync(modelId);
            if (mappedAuthor == null)
            {
                throw new System.Exception("Author wasn't found");
            }
            else
            {

            await _unitOfWork.AuthorRepository.DeleteByIdAsync(modelId);
            await _unitOfWork.SaveAsync();
            }
        }

        public async  Task<AuthorDto> GetByIdAsync(int modelId)
        {
            Author mappedAuthor = await _unitOfWork.AuthorRepository.GetByIdAsync(modelId);
            if (mappedAuthor == null)
            {
                throw new System.Exception("Author wasn't found");
            }
            else
            {

            return _mapper.Map<Author, AuthorDto>(mappedAuthor);
            }
        }



        public async Task UpdateAsync(AuthorDto model)
        {
            Author mappedAuthor = _mapper.Map<AuthorDto, Author>(model);
            if (mappedAuthor == null)
            {
                throw new System.Exception("Author wasn't found");
            }
            else
            {
            _unitOfWork.AuthorRepository.Update(mappedAuthor);
            await _unitOfWork.SaveAsync();
            }
        }
        public IEnumerable<AuthorDto> GetAll()
        {
            return _unitOfWork.AuthorRepository.GetAll().Select(x => _mapper.Map<Author, AuthorDto>(x));
        }
    }
}

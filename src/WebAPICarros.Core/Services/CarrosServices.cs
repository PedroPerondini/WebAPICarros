﻿using System;
using System.Threading.Tasks;
using WebAPICarros.Domain.Model;
using WebAPICarros.Repository.Interfaces;

namespace WebAPICarros.Core.Services
{
    public class CarrosServices : ICarroServices
    {
        private readonly ICarroRepository _carroRepository;

        public CarrosServices(ICarroRepository carroRepository)
        {
            _carroRepository = carroRepository;
        }

        public async Task<CarroModel> GetCarroByIdAsync(int id)
        {
            try
            {
                return await _carroRepository.GetCarroById(id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<CarroModel> CreateCarro(CarroModel carroModel)
        {
            try
            {
                return await _carroRepository.CreateCarro(carroModel);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task UpdateCarroById(int id, CarroModel carroModel)
        {
            try
            {
                await _carroRepository.UpdateCarroById(id, carroModel);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task RemoveCarroById(int id)
        {
            try
            {
                await _carroRepository.RemoveCarroById(id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
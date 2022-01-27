using CleanArch.Application.Cinemas.Commands.Request;
using CleanArch.Application.Cinemas.Commands.Response;
using CleanArch.Domain.Entity;
using CleanArch.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Application.Cinemas.Handlers
{
    public class CreateCinemaCommandHandler
    {
        private readonly CinemaRepository _cinemaRepository;
        public CreateCinemaCommandHandler(CinemaRepository cinemaRepository)
        {
            _cinemaRepository = cinemaRepository;
        }

        public async Task<CreateCinemaCommandResponse> handle(CreateCinemaCommandRequest request)
        {
            var cinema = new Cinema { Name = request.Name, Address = request.Address, CreatedAt = DateTime.Now, Saloons = request.Saloons };
            try
            {
                await _cinemaRepository.Add(cinema);
            }
            catch (Exception)
            {

                throw;
            }

            return new CreateCinemaCommandResponse { IsSucces = true };
        }
    }
}

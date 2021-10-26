using System.Collections.Generic;
using AutoMapper;
using campeonato.Models;
using campeonato.ViewModels.Player.Response;
using campeonato.ViewModels.TournamentPlayer;
using campeonato.ViewModels.TournamentPlayers.Response;

namespace campeonato.AutoMapper
{
    public class AutoMapperSetup : Profile
    {
        public AutoMapperSetup()
        {
            #region Player

            CreateMap<Player, ListPlayerViewModel>();
            
            CreateMap<TournamentPlayer, ListPlayerViewModel>()
                .ForMember(vm => vm.Id,
                    opt => opt
                        .MapFrom(vm => vm.Player.Id)
                )
                .ForMember(vm => vm.Name,
                    opt => opt
                        .MapFrom(vm => vm.Player.Name)
                );
            
            // CreateMap<List<TournamentPlayer>, List<ListPlayerViewModel>>()
            //     .ForMember(vm => vm.Id,
            //         opt => opt
            //             .MapFrom(vm => vm.Player.Id)
            //     )
            //     .ForMember(vm => vm.Name,
            //         opt => opt
            //             .MapFrom(vm => vm.Player.Name)
            //     );

            #endregion
            
            #region TournamentPlayer

            CreateMap<CreateTournamentPlayerViewModel, TournamentPlayer>()
                .ForPath(m => m.Player.Id,
                    opt => opt
                        .MapFrom(vm => vm.PlayerId)
                )
                .ForPath(m => m.Tournament.Id,
                    opt => opt
                        .MapFrom(vm => vm.TournamentId)
                );


            CreateMap<Tournament, DetailsTournamentPlayerViewModel>()
                .ForMember(vm => vm.TournamentName,
                    opt => opt
                        .MapFrom(m => m.Name)
                )
                .ForMember(vm => vm.Start,
                    opt => opt
                        .MapFrom(m => m.Start)
                )
                .ForMember(vm => vm.Players,
                    opt => opt
                        .MapFrom(m => m.Players)
                );

            #endregion
        }
    }
}
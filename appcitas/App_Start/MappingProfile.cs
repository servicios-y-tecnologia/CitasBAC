using appcitas.Dtos;
using appcitas.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace appcitas.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Variable, VariableDto>();
            Mapper.CreateMap<VariableDto, Variable>();
            Mapper.CreateMap<Config, ConfigDto>();
            Mapper.CreateMap<ConfigItem, ConfigItemDto>();
            Mapper.CreateMap<Funcion, FuncionDto>();
            Mapper.CreateMap<FuncionDto, Funcion>();
            Mapper.CreateMap<Parametro, ParametroDto>();
            Mapper.CreateMap<ParametroDto, Parametro>();
            Mapper.CreateMap<Reclamo, ReclamoDto>();
            Mapper.CreateMap<ReclamoDto, Reclamo>();
            Mapper.CreateMap<ItemDeReclamo, ItemDeReclamoDto>();
            Mapper.CreateMap<ItemDeReclamoDto, ItemDeReclamo>();
            Mapper.CreateMap<VariableDeItem, VariableDeItemDto>();
            Mapper.CreateMap<VariableDeItemDto, VariableDeItem>();
            Mapper.CreateMap<Anualidad, AnualidadDto>();
            Mapper.CreateMap<AnualidadVariableEvaluada, AnualidadVariableEvaluadaDto>();
            Mapper.CreateMap<AnualidadResultadoObtenido, AnualidadResultadoObtenidoDto>();
            Mapper.CreateMap<AnualidadDto, Anualidad>();
            Mapper.CreateMap<AnualidadVariableEvaluadaDto, AnualidadVariableEvaluada>();
            Mapper.CreateMap<AnualidadResultadoObtenidoDto, AnualidadResultadoObtenido>();
            Mapper.CreateMap<Reversion, ReversionDto>();
            Mapper.CreateMap<ReversionDto, Reversion>();
            Mapper.CreateMap<VariableReversion, VariableReversionDto>();
            Mapper.CreateMap<VariableReversionDto, VariableReversion>();
            Mapper.CreateMap<ResultadoReversion, ResultadoReversionDto>();
            Mapper.CreateMap<ResultadoReversionDto, ResultadoReversion>();
            Mapper.CreateMap<TasaDto, Tasa>();
            Mapper.CreateMap<TasaVariableEvaluadaDto, TasaVariableEvaluada>();
            Mapper.CreateMap<TasaResultadoDto, TasaResultado>();
            Mapper.CreateMap<Tasa, TasaDto>();
            Mapper.CreateMap<TasaResultado, TasaResultadoDto>();
            Mapper.CreateMap<TasaVariableEvaluada, TasaVariableEvaluadaDto>();
        }
    }
}
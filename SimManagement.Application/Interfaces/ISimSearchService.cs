
using SimManagement.Core.Entities;

namespace SimManagement.Application.Interfaces;

public interface ISimSearchService
{
    Task IndexSimAsync(Sim sim);
}

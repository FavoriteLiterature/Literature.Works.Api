using Literature.Works.Models.Works;
using MediatR;

namespace Literature.Works.Api.Application.Commands.Works;

public class AddWorkRequest : AddWorkRequestModel, IRequest
{
}
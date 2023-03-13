using AutoMapper;
using Domain.Interfaces;
using Entities.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAPIs.Models;

namespace WebAPIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMessage _iMessage;

        public MessageController(IMapper mapper, IMessage iMessage)
        {
            _mapper = mapper;
            _iMessage = iMessage;
        }

        [Authorize]
        [Produces("application/json")]
        [HttpGet("api/GetById")]
        public async Task<MessageViewModel> GetById(Message message)
        {
            message = await _iMessage.GetEntityById(message.Id);
            var messageMapped = _mapper.Map<MessageViewModel>(message);

            return messageMapped;
        }

        [Authorize]
        [Produces("application/json")]
        [HttpGet("api/List")]
        public async Task<List<MessageViewModel>> List()
        {
            var messages = await _iMessage.List();
            var messagesMapped = _mapper.Map<List<MessageViewModel>>(messages);

            return messagesMapped;
        }

        [Authorize]
        [Produces("application/json")]
        [HttpPost("api/Add")]
        public async Task<List<Notifiers>> Add(MessageViewModel message)
        {
            message.UserId = await RetornarUsuarioLogado();
            var messageMapped = _mapper.Map<Message>(message);
            await _iMessage.Add(messageMapped);

            return messageMapped.Notificacoes;
        }

        [Authorize]
        [Produces("application/json")]
        [HttpPost("api/Update")]
        public async Task<List<Notifiers>> Update(MessageViewModel message)
        {
            message.UserId = await RetornarUsuarioLogado();
            var messageMapped = _mapper.Map<Message>(message);
            await _iMessage.Update(messageMapped);

            return messageMapped.Notificacoes;
        }

        [Authorize]
        [Produces("application/json")]
        [HttpPost("api/Delete")]
        public async Task<List<Notifiers>> Delete(MessageViewModel message)
        {
            message.UserId = await RetornarUsuarioLogado();
            var messageMapped = _mapper.Map<Message>(message);
            await _iMessage.Delete(messageMapped);

            return messageMapped.Notificacoes;
        }

        private async Task<string> RetornarUsuarioLogado()
        {
            if(User != null)
            {
                return User.FindFirst("idUsuario").Value;
            }

            return string.Empty;
        }
    }
}

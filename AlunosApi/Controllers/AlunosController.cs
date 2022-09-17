using AlunosApi.Models;
using AlunosApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlunosApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunosController : ControllerBase
    {
        private readonly IAlunoService _alunoService;
        public AlunosController(IAlunoService alunoService)
        {
            _alunoService = alunoService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Aluno>>> Index()
        {
            try
            {
                var alunos = await _alunoService.GetAlunos();
                return Ok(alunos);
            }
            catch
            {
                //return BadRequest("Request inválido");
                return StatusCode(StatusCodes.Status500InternalServerError,
                          "Erro ao acessar dados de alunos");
            }
        }

        [HttpGet("{id:int}", Name = "GetAluno")]
        public async Task<ActionResult<Aluno>> Details(int id)
        {
            var aluno = await _alunoService.GetAluno(id);

            if (aluno == null)
                return NotFound($"Aluno com id= {id} não encontrado");

            return Ok(aluno);
        }

        [HttpPost]
        public async Task<ActionResult> Create(Aluno aluno)
        {
            try
            {
                await _alunoService.CreateAluno(aluno);
                return CreatedAtRoute("GetAluno", new { id = aluno.IdAluno }, aluno);
            }
            catch
            {
                return BadRequest("Request inválido");
            }
        }

        [HttpGet("AlunosPorNome")]
        public async Task<ActionResult<IEnumerable<Aluno>>>
                              GetAlunoPorNome([FromQuery] string nome)
        {
            var alunos = await _alunoService.GetAlunoByNome(nome);

            if (alunos == null)
                return NotFound($"Não existem alunos com nome = {nome}");

            return Ok(alunos);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Edit(int id, [FromBody] Aluno aluno)
        {
            try
            {
                if (aluno.IdAluno == id)
                {
                    await _alunoService.UpdateAluno(aluno);
                    return CreatedAtRoute("GetAluno", new { id = aluno.IdAluno }, aluno);
                }
                else
                {
                    return BadRequest("Dados inválidos");
                }
            }
            catch (Exception)
            {
                return BadRequest("Request inválido");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var aluno = await _alunoService.GetAluno(id);
                if (aluno != null)
                {
                    await _alunoService.DeleteAluno(aluno);
                    return Ok(aluno);
                }
                else
                {
                    return NotFound($"Aluno com id= {id} não encontrado");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}

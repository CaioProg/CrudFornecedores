using CrudFornecedores.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CrudFornecedores.Controllers;
using Newtonsoft.Json;
using System.Text;
using System.Text.Json;
using System.Drawing;
using Microsoft.Extensions.ObjectPool;
using Newtonsoft.Json.Linq;
using CrudFornecedores.Integrations;

namespace CrudFornecedores.Controllers
{
	public class FornecedoresController : Controller
	{
		private readonly Contexto _context;
		
		public FornecedoresController(Contexto context)
		{
			_context = context;
		}

		// GET: Fornecedores
		public async Task<IActionResult> Index()
		{
			return View(await _context.Fornecedor.ToListAsync());
		}

		// GET: Fornecedores/Details/5
		public async Task<IActionResult> Details(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var fornecedor = await _context.Fornecedor
				.FirstOrDefaultAsync(m => m.Id == id);
			if (fornecedor == null)
			{
				return NotFound();
			}

			return View(fornecedor);
		}

		// GET: Fornecedores/Create
		public IActionResult Create()
		{
			return View();
		}

		// POST: Fornecedores/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create([Bind("Id,Nome,Cnpj,Especialidade")] Fornecedor fornecedor)
		{
			if (ModelState.IsValid)
			{
				_context.Add(fornecedor);

				// creates on ploomes
				await Ploomes.CreateCompanyPloomesAsync(fornecedor);
				await _context.SaveChangesAsync();
				return RedirectToAction(nameof(Index));
			}
			return View(fornecedor);
		}

		// GET: Fornecedores/Edit/5
		public async Task<IActionResult> Edit(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var fornecedor = await _context.Fornecedor.FindAsync(id);
			if (fornecedor == null)
			{
				return NotFound();
			}
			return View(fornecedor);
		}

		// POST: Forncecedor/Edit/5

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Cnpj,Especialidade")] Fornecedor fornecedor)
		{
			if (id != fornecedor.Id)
			{
				return NotFound();
			}

			if (ModelState.IsValid)
			{
				try
				{
					_context.Update(fornecedor);
					await _context.SaveChangesAsync();
					await Ploomes.EditCompanyPloomesAsync(fornecedor);
				}
				catch (DbUpdateConcurrencyException)
				{
					if (!FornecedorExists(fornecedor.Id))
					{
						return NotFound();
					}
					else
					{
						throw;
					}
				}
				return RedirectToAction(nameof(Index));
			}
			return View(fornecedor);
		}

		// GET: Fornecedor/Delete/5
		public async Task<IActionResult> Delete(int? id, Fornecedor fornecedor)
		{
			if (id == null)
			{
				return NotFound();
			}
			
			fornecedor = await _context.Fornecedor
				.FirstOrDefaultAsync(m => m.Id == id);

			// deletes in ploomes
			await Ploomes.DeleteCompanyPloomesAsync(fornecedor);

			if (fornecedor == null)
			{
				return NotFound();
			}

			return View(fornecedor);
		}

		// POST: Fornecedor/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			var fornecedor = await _context.Fornecedor.FindAsync(id);
			_context.Fornecedor.Remove(fornecedor);
			await _context.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		}

		private bool FornecedorExists(int id)
		{
			return _context.Fornecedor.Any(e => e.Id == id);
		}

		
	}
}
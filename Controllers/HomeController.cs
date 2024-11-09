using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.FileSystemGlobbing;
using MvcMastery.Models;
using MvcMastery.Services;

namespace MvcMastery.Controllers;

public class HomeController : Controller
{
    private readonly InMemoryPersonelService _personelService;

    public HomeController(InMemoryPersonelService personelService)
    {
        _personelService = personelService;
    }

    public IActionResult Index()
    {
        var personels = _personelService.GetAll();
        return View(personels);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(Personel personel)
    {
        if (ModelState.IsValid)
        {
            _personelService.CreatePersonel(personel);
            return RedirectToAction("Index");
        }
        ModelState.AddModelError(string.Empty, "Personel Verileri Hatalı. Ekleme Başarısız !!");
        return View(personel);
    }

    [HttpGet]
    public IActionResult Edit(int personelId)
    {
        var personel = _personelService.GetById(personelId);
        if (personel == null)
        {
            return NotFound();
        }
        return View(personel);
    }

    [HttpPost]
    public IActionResult Edit(Personel personel)
    {
        if (ModelState.IsValid)
        {
            _personelService.UpdatePersonel(personel);
            return RedirectToAction("Index");
        }
        ModelState.AddModelError(string.Empty, "Personel Verileri Hatalı. Güncelleme Başarısız !!");
        return View(personel);
    }

    [HttpGet]
    public IActionResult Delete(int personelId)
    {
        var personel = _personelService.GetById(personelId);

        if (personel == null)
        {
            return NotFound();
        }
        return View(personel);
    }

    [HttpPost]
    public IActionResult DeleteConfirmed(int personelId)
    {
        _personelService.DeletePersonel(personelId);
        return RedirectToAction("Index");
    }
}

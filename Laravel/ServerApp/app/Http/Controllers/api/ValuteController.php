<?php

namespace App\Http\Controllers\api;

use App\Http\Controllers\Controller;
use App\Models\Valute;
use Illuminate\Http\Request;

class ValuteController extends Controller
{

    public function index()
    {
        return Valute::all();
    }


    public function store(Request $request)
    {
        //
    }

    public function show($id)
    {
        //
    }

    public function update(Request $request, $id)
    {
        //
    }

    public function destroy($id)
    {
        //
    }
}

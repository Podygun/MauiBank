<?php

namespace App\Http\Controllers\api;

use App\Http\Controllers\Controller;
use App\Models\Favour;
use Illuminate\Http\Request;

class FavourController extends Controller
{

    public function index()
    {
        return Favour::all();
    }

    public function store(Request $request)
    {
        $favour = Favour::create($request->all);
        return $favour;
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

    public function getPrimaryFavours(){
        return Favour::query()
            ->where('')
    }
}

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
        return Favour::find($id);
    }

    public function update(Request $request, $id)
    {
        //
    }

    public function destroy($id)
    {
        //
    }

    public function primary()
    {
        return Favour::query()->where('favour_id', null) ->get();
    }

    public function secondary(Request $request)
    {
        return Favour::query()->where('favour_id', $request->id) ->get();
    }

//    public function getPrimaryFavours(){
//        return Favour::query()
//            ->where('')
//    }
}

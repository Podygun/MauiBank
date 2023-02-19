<?php

namespace App\Http\Controllers\api;

use App\Http\Controllers\Controller;
use App\Models\Card;
use Illuminate\Http\Request;

class CardController extends Controller
{

    public function index()
    {
        return Card::all();
    }


    public function store(Request $request)
    {
        $card = Card::create($request->all());
        return $card;
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

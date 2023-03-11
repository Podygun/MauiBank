<?php

namespace App\Http\Controllers\api;

use App\Http\Controllers\Controller;
use App\Models\Client;
use Illuminate\Http\Request;

class ClientController extends Controller
{

    public function index()
    {
        return Client::all();
    }

    public function store(Request $request)
    {
        $client = Client::create($request->all());

        return $client;
    }

    public function show($id)
    {
        return Client::find($id);
    }

    public function getOnUserAccountId(Request $request)
    {
        return Client::where('user_account_id', $request->id)
            ->get('id')->first();
    }

    public function getAllOnUserAccountId(Request $request)
    {
        return Client::where('user_account_id', $request->id)
            ->get()->first();
    }

    public function update(Request $request, $id)
    {
        $oldClient = Client::find($id);
        $oldClient->update($request->json()->all());
        return $oldClient;


    }

    public function destroy($id)
    {
        //
    }
}

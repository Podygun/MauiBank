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

    public function store(Request $request, $id)
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
        $oldClient->first_name = $request->input('first_name');
        $oldClient->second_name = $request->input('second_name');
        $oldClient->last_name = $request->input('last_name');
        $oldClient->email = $request->input('email');
        $oldClient->phone = $request->input('phone');
        $oldClient->save();
        $oldClient->update($request->json()->all());
        return response()->json(['message' => 'Client updated']);
    }

    public function destroy($id)
    {
        //
    }
}

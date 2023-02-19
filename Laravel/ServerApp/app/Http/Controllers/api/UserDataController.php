<?php

namespace App\Http\Controllers\api;

use App\Http\Controllers\Controller;
use App\Models\Client;
use Illuminate\Http\Request;
use Illuminate\Support\Facades\DB;

class UserDataController extends Controller
{
    public function index()
    {
        return DB::table('bank_accounts')
            ->select(
                'bank_accounts.balance'
                , 'bank_accounts.client_id'
                , 'valutes.code as valute_code'
                , 'clients.first_name'
                , 'clients.second_name'
                , 'clients.last_name'
                , 'clients.phone'
                , 'clients.email'
                ,'cards.number'
                ,'cards.cvv'
                ,'cards.date_end'

                ,'card_types.name as card_type_name'
            )
            ->join('valutes','bank_accounts.valute_id','=','valutes.id')
            ->join('clients','bank_accounts.client_id','=','clients.id')
            ->join('cards','bank_accounts.id','=','cards.bank_account_id')
            ->join('card_types','cards.card_type_id','=','card_types.id')
            ->get();
    }

    /**
     * Store a newly created resource in storage.
     *
     * @param  \Illuminate\Http\Request  $request
     * @return \Illuminate\Http\Response
     */
    public function store(Request $request)
    {
        //
    }

    public function show($id)
    {
        $clientId = client::where('user_account_id', $id)->get('id')->first();

        return DB::table('bank_accounts')
            ->select(
                'bank_accounts.balance'
                , 'bank_accounts.client_id'
                , 'valutes.code as valute_code'
                , 'clients.first_name'
                , 'clients.second_name'
                , 'clients.last_name'
                , 'clients.phone'
                , 'clients.email'
                ,'cards.number'
                ,'cards.cvv'
                ,'cards.date_end'

                ,'card_types.name as card_type_name'
            )
            ->join('valutes','bank_accounts.valute_id','=','valutes.id')
            ->join('clients','bank_accounts.client_id','=','clients.id')
            ->join('cards','bank_accounts.id','=','cards.bank_account_id')
            ->join('card_types','cards.card_type_id','=','card_types.id')
            ->where('bank_accounts.client_id', $clientId->id)
            ->get();

    }

    /**
     * Update the specified resource in storage.
     *
     * @param  \Illuminate\Http\Request  $request
     * @param  int  $id
     * @return \Illuminate\Http\Response
     */
    public function update(Request $request, $id)
    {
        //
    }

    /**
     * Remove the specified resource from storage.
     *
     * @param  int  $id
     * @return \Illuminate\Http\Response
     */
    public function destroy($id)
    {
        //
    }
}

<?php

namespace App\Http\Controllers;

use App\Models\Animal;
use App\Models\Bank_account;
use App\Models\Client;
use App\Models\Card;
use Illuminate\Http\Request;
use Illuminate\Support\Facades\DB;

class UserDataController extends Controller
{

    public function get(Request $request){
        $clientId = client::where('user_account_id', $request->userId)->get('id')->first();
        $userData = DB::table('bank_accounts')
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
        return $userData;
    }

}

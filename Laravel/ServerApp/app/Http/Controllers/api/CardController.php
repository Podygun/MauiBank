<?php

namespace App\Http\Controllers\api;

use App\Http\Controllers\Controller;
use App\Models\Card;
use Illuminate\Http\Request;
use Illuminate\Support\Facades\DB;

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
        return DB::table('cards as c')
            ->select(
                'c.number as number'
                , 'c.cvv as cvv'
                 , 'c.date_end as date_end'
                 , 'c.bank_account_id as bank_account_id'
                 , 'bacc.balance as balance'
                 , 'types.name as type_name'
                 , 'valutes.code as valute'
            )
            ->join('bank_accounts as bacc','c.bank_account_id','=','bacc.id')
            ->join('clients as cls','bacc.client_id','=','cls.id')
            ->join('card_types as types','c.card_type_id','=','types.id')
            ->join('valutes','bacc.valute_id','=','valutes.id')
            ->where('cls.user_account_id', $id)
            ->get();
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

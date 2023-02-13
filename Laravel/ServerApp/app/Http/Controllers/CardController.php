<?php

namespace App\Http\Controllers;

use App\Models\Bank_account;
use App\Models\Client;
use Illuminate\Http\Request;
use Illuminate\Support\Facades\DB;
use App\Models\Card;

class CardController extends Controller
{
    public function create(Request $request): Card
    {
        $card = new Card();

        $card->number = $request->number;
        $card->cvv = $request->cvv;
        $card->date_end = $request->date_end;
        $card->bank_account_id = $request->bank_account_id;

        $card->save();
        return $card;
    }

    public function update()
    {
        $card = Card::find(1);
        $card->update([
            'number'=>'updated',
        ]);
        return $card;
    }

    public function delete()
    {
        $card = Card::find(2);
        $card->delete();
        return dd('deleted');

//        Восстановление
//        $card = Card::withTrashed()->find(1);
//        $card->restore();
//        return dd('restored');
    }

    public function index()
    {
        return Card::all();
    }



    public function user_card(Request $request)
    {

    }


}

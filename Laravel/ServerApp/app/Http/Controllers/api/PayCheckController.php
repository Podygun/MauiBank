<?php

namespace App\Http\Controllers\api;

use App\Http\Controllers\Controller;
use App\Models\Pay_check;
use Illuminate\Http\Request;
use Illuminate\Support\Facades\DB;

class PayCheckController extends Controller
{

    public function index()
    {
        //
    }


    public function store(Request $request)
    {
        $created_payCheck = Pay_check::create($request->all());
        return $created_payCheck;
    }

    public function show($id)
    {
        return Pay_check::find($id);
    }


    public function update(Request $request, Pay_check $paycheck)
    {
        //$paycheck->update()
    }

    public function findByBankAccId(Request $request )
    {
        return DB::table('pay_checks as pc')
            ->select(
                'pc.updated_at as time'
                , 'pc.sum as sum'
                , 'pc.fee as fee'
                , 'pc.requisite_value as requisite_value'
                , 'c.first_name as first_name'
                , 'c.second_name as second_name'
                , 'c.last_name as last_name'
                , 'v.code as valute'
                , 'f.name as favour'
            )
            ->join('bank_accounts as bacc', 'pc.bank_account_id', '=', 'bacc.id' )
            ->join('clients as c', 'bacc.client_id', '=', 'c.id' )
            ->join('valutes as v', 'bacc.valute_id', '=', 'v.id' )
            ->join('favours as f', 'pc.favour_id', '=', 'f.id' )

            ->where('pc.bank_account_id', $request->id)
            ->orderBy('pc.updated_at')
            ->get();


    }

    public function destroy($id)
    {
        //
    }
}

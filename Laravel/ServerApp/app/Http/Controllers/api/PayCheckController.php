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

    public function short(Request $request)
    {
        return DB::table('pay_checks as pc')
            ->select(
                DB::raw("DATE_FORMAT(pc.updated_at, '%d.%m.%Y') as Time")
                , 'pc.id as Id'
                , 'pc.sum as Sum'
                , 'pc.requisite_value as Requisite_value'
                , 'v.code as Valute'
                , 'f.name as Favour'
            )
            ->join('bank_accounts as bacc', 'pc.bank_account_id', '=', 'bacc.id' )
            ->join('valutes as v', 'bacc.valute_id', '=', 'v.id' )
            ->join('favours as f', 'pc.favour_id', '=', 'f.id' )
            ->where('pc.bank_account_id', $request->id)
            ->orWhere('pc.to_bank_account_id', $request->id)
            ->orderBy('pc.updated_at')
            ->get();
    }

    public function getAllFields(Request $request)
    {
        $temp = DB::table('pay_checks as pc')
            ->select(
                DB::raw("DATE_FORMAT(pc.updated_at, '%d.%m.%Y %H:%i:%s') as Time")
                , 'pc.id as Id'
                , 'pc.sum as Sum'
                , 'pc.fee as Fee'
                , 'pc.requisite_value as Requisite_value'
                , 'pc.bank_account_id as Bank_account_id'
                , 'pc.to_bank_account_id as To_bank_account_id'
                , 'senderClient.first_name as Sender_First_name'
                , 'senderClient.second_name as Sender_Second_name'
                , 'senderClient.last_name as Sender_Last_name'
                , 'recieverClient.first_name as Reciever_First_name'
                , 'recieverClient.second_name as Reciever_Second_name'
                , 'recieverClient.last_name as Reciever_Last_name'
                , 'v.code as Valute'
                , 'f.name as Favour'
            )
            ->join('bank_accounts as senderBankAcc', 'pc.bank_account_id', '=', 'senderBankAcc.id' )
            ->join('bank_accounts as recieverBankAcc', 'pc.to_bank_account_id', '=', 'recieverBankAcc.id' )
            ->join('clients as senderClient', 'senderBankAcc.client_id', '=', 'senderClient.id' )
            ->join('clients as recieverClient', 'recieverBankAcc.client_id', '=', 'recieverClient.id' )
            ->join('valutes as v', 'senderBankAcc.valute_id', '=', 'v.id' )
            ->join('favours as f', 'pc.favour_id', '=', 'f.id' )
            ->where('pc.id', $request->id)
            ->orderBy('pc.updated_at')
            ->first();
        return [$temp];
    }

    public function destroy($id)
    {
        //
    }
}

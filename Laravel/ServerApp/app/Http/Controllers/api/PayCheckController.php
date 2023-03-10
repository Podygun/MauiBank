<?php

namespace App\Http\Controllers\api;

use App\Http\Controllers\Controller;
use App\Models\Pay_check;
use Illuminate\Http\Request;

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

    public function destroy($id)
    {
        //
    }
}

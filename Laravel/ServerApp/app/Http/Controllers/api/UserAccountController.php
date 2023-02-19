<?php

namespace App\Http\Controllers\api;

use App\Http\Controllers\Controller;
use Illuminate\Http\Request;
use App\Models\User_account;

class UserAccountController extends Controller
{

    public function index()
    {
        return User_account::all();
    }

    public function store(Request $request)
    {
        $user_account = User_account::create($request->all());
        return $user_account;
    }

    public function get(Request $request){
        return User_account::where('login', $request->login)
            ->where('password', $request->password)
            ->get('id')->first();
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

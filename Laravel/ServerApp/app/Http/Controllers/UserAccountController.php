<?php

namespace App\Http\Controllers;

use Illuminate\Http\Request;
use App\Models\User_account;

class UserAccountController extends Controller
{
    public function store(Request $request)
    {
        $user_account = User_account::create($request->all);
        return new User_account($user_account);
//        $user_account->login = $request->login;
//        $user_account->password = $request->password;
//        $user_account->salt = $request->salt;
//
//        $user_account->save();
//        return 'ok';
    }

    public function update(Request $request)
    {
        $user_account = User_account::find(1);
        $user_account->update([
            'number'=>'updated',
        ]);
        return 'ok';
    }

    public function delete(Request $request)
    {
        $user_account = User_account::find($request->id);
        $user_account->delete();
        return 'ok';

//        Восстановление
//        $user_account = Card::withTrashed()->find(1);
//        $card->restore();
//        return dd('restored');
    }

    public function index()
    {
        return User_account::all();
    }

    public function getId(Request $request)
    {
        return User_account::where('login', $request->login)
            ->where('password', $request->password)
            ->get('id')->first();
    }



}

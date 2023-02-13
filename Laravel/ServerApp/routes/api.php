<?php

use Illuminate\Http\Request;
use Illuminate\Support\Facades\Route;

use App\Http\Controllers;
/*
|--------------------------------------------------------------------------
| API Routes
|--------------------------------------------------------------------------
|
| Here is where you can register API routes for your application. These
| routes are loaded by the RouteServiceProvider within a group which
| is assigned the "api" middleware group. Enjoy building your API!
|
*/

//Route::middleware('auth:api')->get('/user', function (Request $request) {
//    return $request->user();
//});

//?number=test&cvv=123&date_end=2023.12.1&bank_account_id=1
Route::get('/cards/create', [Controllers\CardController::class, 'create']);
Route::get('/cards/update', [Controllers\CardController::class, 'update']);
Route::get('/cards/delete', [Controllers\CardController::class, 'delete']);
Route::get('/cards/client', [Controllers\CardController::class, 'user_card']);

Route::get('/users/create', [Controllers\UserAccountController::class, 'create']);
Route::get('/users/update', [Controllers\UserAccountController::class, 'update']);
Route::get('/users/delete', [Controllers\UserAccountController::class, 'delete']);
Route::get('/users/get', [Controllers\UserAccountController::class, 'getId']);


Route::get('/userdata', [Controllers\UserDataController::class, 'get']);



#$users = DB::select('select * from users where active = ?', [1]);

<?php

use Illuminate\Http\Request;
use Illuminate\Support\Facades\Route;

use App\Http\Controllers;
use App\Http\Controllers\api;
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
//Route::get('/cards/create', [Controllers\CardController::class, 'create']);
//Route::get('/cards/update', [Controllers\CardController::class, 'update']);
//Route::get('/cards/delete', [Controllers\CardController::class, 'delete']);
//Route::get('/cards/client', [Controllers\CardController::class, 'user_card']);

//Route::get('/users/create', [Controllers\UserAccountController::class, 'create']);
//Route::get('/users/update', [Controllers\UserAccountController::class, 'update']);
//Route::get('/users/delete', [Controllers\UserAccountController::class, 'delete']);

Route::get('/userAccounts/get',
    [Controllers\api\UserAccountController::class, 'get']);
Route::get('/clients/getOnUserAccountId',
    [Controllers\api\ClientController::class, 'getOnUserAccountId']);
Route::get('/clients/getAllOnUserAccountId',
    [Controllers\api\ClientController::class, 'getAllOnUserAccountId']);
Route::get('/favours/primary',
    [Controllers\api\FavourController::class, 'primary']);
Route::get('/favours/secondary',
    [Controllers\api\FavourController::class, 'secondary']);



Route::get('/listRequisites/getOnFavour',
    [Controllers\api\ListRequisitesController::class, 'getOnFavour']);


Route::apiResources([
    'userdata' => api\UserDataController::class
    , 'userAccounts'=>api\UserAccountController::class
    , 'valutes'=>api\ValuteController::class
    , 'clients'=>api\ClientController::class
    , 'cards'=>api\CardController::class
    , 'favours'=>api\FavourController::class
    , 'listRequisites'=>api\ListRequisitesController::class
    , 'payCheck'=>api\PayCheckController::class
]);



#$users = DB::select('select * from users where active = ?', [1]);

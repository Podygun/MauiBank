<?php

namespace App\Http\Controllers\api;

use App\Http\Controllers\Controller;
use Illuminate\Http\Request;
use Illuminate\Support\Facades\DB;

class OrganisationController extends Controller
{

    public function index()
    {
        //
    }

    public function store(Request $request)
    {
        //
    }

    public function show($id)
    {
        //
    }

    public function update(Request $request, $id)
    {
        //
    }

    public function destroy($id)
    {
        //
    }

    public function getOrganisationsOnFavourId(Request $request)
    {
        return DB::table('list_requisites as lists')
            ->join('organisations as org','lists.organisation_id', '=', 'org.id')
            ->join('favours as f','f.id', '=', 'lists.favour_id')
            ->select(
                'org.id as Id'
                , 'org.name as Name'
                , 'org.money_number as Money_number')

            ->where('f.id',$request->id)
            ->get();
    }
}

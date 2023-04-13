<?php

namespace App\Http\Controllers\api;

use App\Http\Controllers\Controller;
use App\Models\ListRequisites;
use Illuminate\Http\Request;


class ListRequisitesController extends Controller
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
        $list = ListRequisites::find($id);
        return $list;
    }

    public function getOnFavour(request $request)
    {

        return DB::table('list_requisites')
            ->join('requisites','list_requisites.requisite_id', '=', 'requisites.id')
            ->join('organisations','list_requisites.organisation_id', '=', 'organisations.id')
            ->join('favours','list_requisites.favour_id', '=', 'favours.id')
            ->select(
                'list_requisites.id'
                , 'requisite_id'
                , 'requisites.name as requisite_name'
                , 'organisation_id'
                , 'organisations.name as organisation_name'
                , 'list_requisites.favour_id'
                , 'favours.name as favour_name')

            ->where('list_requisites.favour_id', $request->id)
            ->get();
    }

    public function getOnOrganisationId(request $request)
    {
        return DB::table('list_requisites as lists')
            ->select(
                'req.id as Id'
                , 'req.name as Name')
            ->join('organisations as org','lists.organisation_id', '=', 'org.id')
            ->join('requisites as req','req.id', '=', 'lists.requisite_id')
            ->where('org.id', $request->id)
            ->distinct()
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

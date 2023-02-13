<?php

use Illuminate\Database\Migrations\Migration;
use Illuminate\Database\Schema\Blueprint;
use Illuminate\Support\Facades\Schema;

class CreateListRequisitesTable extends Migration
{
    public function up()
    {
        Schema::create('list_requisites', function (Blueprint $table) {
            $table->id();
            $table->softDeletes();

            $table->unsignedBigInteger('requisite_id')->nullable();
            $table->index('requisite_id', 'list_requisite_idx');
            $table->foreign('requisite_id', 'list_requisite_fk')
                                ->on('requisites')->references('id');

            $table->unsignedBigInteger('organisation_id')->nullable();
            $table->index('organisation_id', 'list_organisation_idx');
            $table->foreign('organisation_id', 'list_organisation_fk')
                ->on('organisations')->references('id');
        });
    }

    public function down()
    {
        Schema::dropIfExists('list_requisites');
    }
}

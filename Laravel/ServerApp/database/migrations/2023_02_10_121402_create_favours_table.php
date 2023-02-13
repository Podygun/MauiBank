<?php

use Illuminate\Database\Migrations\Migration;
use Illuminate\Database\Schema\Blueprint;
use Illuminate\Support\Facades\Schema;

class CreateFavoursTable extends Migration
{

    public function up()
    {
        Schema::create('favours', function (Blueprint $table) {
            $table->id();
            $table->string('name');

            $table->softDeletes();

//            $table->unsignedBigInteger('favour_id')->nullable();
//            $table->index('favour_id', 'favour_favour_idx');
//            $table->foreign('favour_id', 'favour_favour_fk')
//                                ->on('favour')->references('id');

        });
    }

    public function down()
    {
        Schema::dropIfExists('favours');
    }
}

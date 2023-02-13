<?php

use Illuminate\Database\Migrations\Migration;
use Illuminate\Database\Schema\Blueprint;
use Illuminate\Support\Facades\Schema;

class CreateValutesTable extends Migration
{

    public function up()
    {
        Schema::create('valutes', function (Blueprint $table) {
            $table->id();
            $table->string('code', 5);
            $table->integer('measure');
            $table->double('course');
            $table->softDeletes();
        });
    }

    public function down()
    {
        Schema::dropIfExists('valutes');
    }
}

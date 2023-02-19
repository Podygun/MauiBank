<?php

use Illuminate\Database\Migrations\Migration;
use Illuminate\Database\Schema\Blueprint;
use Illuminate\Support\Facades\Schema;

class AddColumnFavouridToFavoursTable extends Migration
{
    /**
     * Run the migrations.
     *
     * @return void
     */
    public function up()
    {
        Schema::table('favours', function (Blueprint $table) {
            $table->unsignedBigInteger('favour_id')->nullable();
            $table->index('favour_id', 'favour_favour_idx');
            $table->foreign('favour_id', 'favour_favour_fk')
                                ->on('favour')->references('id');
        });
    }

    public function down()
    {
        Schema::table('favours', function (Blueprint $table) {
            //
        });
    }
}

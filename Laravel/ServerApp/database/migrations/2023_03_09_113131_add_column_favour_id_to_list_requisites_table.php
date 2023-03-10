<?php

use Illuminate\Database\Migrations\Migration;
use Illuminate\Database\Schema\Blueprint;
use Illuminate\Support\Facades\Schema;

class AddColumnFavourIdToListRequisitesTable extends Migration
{

    public function up()
    {
        Schema::table('list_requisites', function (Blueprint $table) {
            $table->unsignedBigInteger('favour_id')->nullable()->default(1);
            $table->index('favour_id', 'list_favours_idx');
            $table->foreign('favour_id', 'list_favours_fk')
                ->on('favours')->references('id');
        });
    }

    public function down()
    {
        Schema::table('list_requisites', function (Blueprint $table) {
            $table->dropColumn('favour_id');
            $table->dropForeign('list_favours_fk');
            $table->dropIndex('list_favours_idx');
            $table->dropColumn('favour_id');
        });
    }
}

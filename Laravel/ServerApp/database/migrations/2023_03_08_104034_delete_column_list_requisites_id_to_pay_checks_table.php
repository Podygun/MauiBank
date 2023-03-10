<?php

use Illuminate\Database\Migrations\Migration;
use Illuminate\Database\Schema\Blueprint;
use Illuminate\Support\Facades\Schema;

class DeleteColumnListRequisitesIdToPayChecksTable extends Migration
{
    /**
     * Run the migrations.
     *
     * @return void
     */
    public function up()
    {
        Schema::table('pay_checks', function (Blueprint $table) {
            $table->dropForeign('check_list_requisites_fk');
            $table->dropIndex('check_list_requisites_idx');
            $table->dropColumn('list_requisites_id');

        });
    }

    /**
     * Reverse the migrations.
     *
     * @return void
     */
    public function down()
    {
        Schema::table('pay_checks', function (Blueprint $table) {
            $table->unsignedBigInteger('list_requisites_id')->nullable();
            $table->index('list_requisites_id', 'check_list_requisites_idx');
            $table->foreign('list_requisites_id', 'check_list_requisites_fk')
                ->on('list_requisites')->references('id');
        });
    }
}

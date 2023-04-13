<?php

use Illuminate\Database\Migrations\Migration;
use Illuminate\Database\Schema\Blueprint;
use Illuminate\Support\Facades\Schema;

class AddRecieverBankAccountToPayChecksTable extends Migration
{
    /**
     * Run the migrations.
     *
     * @return void
     */
    public function up()
    {
        Schema::table('pay_checks', function (Blueprint $table) {
            $table->string('to_bank_account_id')->nullable()->after('bank_account_id');
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
            $table->dropColumn('to_bank_account_id');
        });
    }
}

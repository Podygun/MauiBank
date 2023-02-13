<?php

use Illuminate\Database\Migrations\Migration;
use Illuminate\Database\Schema\Blueprint;
use Illuminate\Support\Facades\Schema;

class CreateBankAccountsTable extends Migration
{

    public function up()
    {
        Schema::create('bank_accounts', function (Blueprint $table) {
            $table->id();
            $table->double('balance');

            $table->softDeletes();

            $table->unsignedBigInteger('valute_id')->nullable();
            $table->index('valute_id', 'bank_account_valute_idx');
            $table->foreign('valute_id', 'bank_account_valute_fk')
                                ->on('valutes')->references('id');

            $table->unsignedBigInteger('client_id')->nullable();
            $table->index('client_id', 'bank_account_client_idx');
            $table->foreign('client_id', 'bank_account_client_fk')
                ->on('clients')->references('id');
        });
    }

    public function down()
    {
        Schema::dropIfExists('bank_accounts');
    }
}

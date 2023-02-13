<?php

use Illuminate\Database\Migrations\Migration;
use Illuminate\Database\Schema\Blueprint;
use Illuminate\Support\Facades\Schema;

class CreatePayChecksTable extends Migration
{

    public function up()
    {
        Schema::create('pay_checks', function (Blueprint $table) {
            $table->id();
            $table->timestamps();
            $table->double('sum');
            $table->double('fee');

            $table->softDeletes();

            $table->unsignedBigInteger('bank_account_id')->nullable();
            $table->index('bank_account_id', 'check_bank_account_idx');
            $table->foreign('bank_account_id', 'check_bank_account_fk')
                                ->on('bank_accounts')->references('id');

            $table->unsignedBigInteger('list_requisites_id')->nullable();
            $table->index('list_requisites_id', 'check_list_requisites_idx');
            $table->foreign('list_requisites_id', 'check_list_requisites_fk')
                ->on('list_requisites')->references('id');

            $table->unsignedBigInteger('favour_id')->nullable();
            $table->index('favour_id', 'check_favour_idx');
            $table->foreign('favour_id', 'check_favour_fk')
                ->on('favours')->references('id');
        });
    }

    public function down()
    {
        Schema::dropIfExists('pay_checks');
    }
}

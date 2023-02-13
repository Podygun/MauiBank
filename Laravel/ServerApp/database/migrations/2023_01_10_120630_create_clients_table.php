<?php

use Illuminate\Database\Migrations\Migration;
use Illuminate\Database\Schema\Blueprint;
use Illuminate\Support\Facades\Schema;

class CreateClientsTable extends Migration
{

    public function up()
    {
        Schema::create('clients', function (Blueprint $table) {
            $table->id();
            $table->string('first_name');
            $table->string('second_name');
            $table->string('last_name')->nullable();
            $table->string('gender', 10);
            $table->string('email')->nullable();
            $table->string('phone');

            $table->unsignedBigInteger('user_account_id')->nullable();
            $table->softDeletes();

            $table->index('user_account_id', 'client_user_account_idx');

            $table->foreign('user_account_id', 'client_user_account_fk')
                ->on('user_accounts')->references('id');

        });
    }

    public function down()
    {
        Schema::dropIfExists('clients');
    }
}

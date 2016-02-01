<?php

/**
 * CaptchaConfig short summary.
 *
 * CaptchaConfig description.
 *
 * @version 1.0
 * @author Sandeepan Kundu
 */
require ("configuration.php");
class CaptchaConfig
{
    private $_captchasecret;
    function __construct()
    {
        $_captchasecret = CAPTCHA_SECRET;
    }

    public function getKey(){
        return $_captchasecret;
    }
}

?>